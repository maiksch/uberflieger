import {
  createLessonId,
  Lesson,
  Result,
  TaskResult,
  UnsavedLesson,
} from '@domain';
import { LessonRepository } from '@infrastructure';
import { pipe } from 'fp-ts/lib/function';
import { chain, fromEither } from 'fp-ts/lib/TaskEither';

interface CreateLessonDto {
  moduleId: number;
  videoId?: number;
  title: string;
  thumbnail: string;
}

interface UpdateLessonDto {
  id: number;
  moduleId: number;
  videoId?: number;
  title: string;
  thumbnail: string;
}

function create(dto: CreateLessonDto): TaskResult<Lesson> {
  return pipe(UnsavedLesson(dto), chainFromEither(LessonRepository.create));
}

function getList(): TaskResult<Lesson[]> {
  return LessonRepository.find();
}

function getOne(id: number): TaskResult<Lesson> {
  return pipe(createLessonId(id), chainFromEither(LessonRepository.findById));
}

function update(dto: UpdateLessonDto): TaskResult<Lesson> {
  return pipe(Lesson(dto), chainFromEither(LessonRepository.update));
}

function remove(id: number): TaskResult<null> {
  return pipe(createLessonId(id), chainFromEither(LessonRepository.remove));
}

export const LessonService = {
  create,
  getList,
  getOne,
  update,
  remove,
};

function chainFromEither<A, B>(
  f: (a: A) => TaskResult<B>
): (ma: Result<A>) => TaskResult<B> {
  return (ma: Result<A>) => {
    return pipe(fromEither(ma), chain(f));
  };
}
