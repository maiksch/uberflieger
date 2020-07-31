import { sequenceS } from 'fp-ts/lib/Apply';
import { getValidation, isLeft, left, right } from 'fp-ts/lib/Either';
import { getSemigroup, fromArray } from 'fp-ts/lib/ReadonlyNonEmptyArray';
import { Result } from '../results';
import {
  createLessonThumbnail,
  createModuleId,
  createString256,
  LessonId,
  LessonThumbnail,
  ModuleId,
  String256,
  VideoId,
  createLessonId,
} from '../simple-types';
import { isSome } from 'fp-ts/lib/Option';

export interface UnsavedLesson {
  moduleId: ModuleId;
  videoId?: VideoId;
  title: String256;
  thumbnail: LessonThumbnail;
}

export function UnsavedLesson(input: {
  title: string;
  thumbnail: string;
  moduleId: number;
}): Result<UnsavedLesson> {
  return validate({
    title: createString256(input.title),
    moduleId: createModuleId(input.moduleId),
    thumbnail: createLessonThumbnail(input.thumbnail),
  });
}

export type Lesson = UnsavedLesson & {
  id: LessonId;
};

// export type DraftedLesson = Lesson & { _type_: 'DraftedLesson' };
// export type PublishedLesson = Lesson & { _type_: 'PublishedLesson' };

export function Lesson(input: {
  id: number;
  title: string;
  thumbnail: string;
  moduleId: number;
}): Result<Lesson> {
  return validate({
    id: createLessonId(input.id),
    title: createString256(input.title),
    moduleId: createModuleId(input.moduleId),
    thumbnail: createLessonThumbnail(input.thumbnail),
  });
}

export function Lessons(input: any[]): Lesson[] {
  return input.map((i) => ({
    id: LessonId(i.id),
    title: String256(i.title),
    // video: `${__dirname}/assets/small.webm`,
    thumbnail: LessonThumbnail(i.thumbnail),
    moduleId: ModuleId(i.moduleId),
  }));
}

// function validate() {
//   return sequenceS(getValidation(getSemigroup<Error>()));
// }

function validate<A>(
  input: { [K in keyof A]: Result<A[K]> | ((context: string) => Result<A[K]>) }
): Result<A> {
  let errors: Array<Error> = [];
  let obj: any = {};

  Object.entries<Result<unknown> | ((context: string) => Result<any>)>(
    input
  ).forEach(([key, result]) => {
    if (result instanceof Function) {
      result = result(key);
    }

    if (isLeft(result)) {
      errors = [...errors, ...result.left];
    } else {
      obj = { ...obj, [key]: result.right };
    }
  });

  if (errors.length > 0) {
    return left(errors);
    // const readonlyArrayErrors = fromArray(errors);
    // if (isSome(readonlyArrayErrors)) {
    // return left(readonlyArrayErrors.value);
    // } else {
    //   throw new Error('This should not have happened');
    // }
  }

  return right(obj);
}
