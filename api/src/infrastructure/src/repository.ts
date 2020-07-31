import { Lesson, LessonId, Lessons, TaskResult, UnsavedLesson } from '@domain';
import { isRight } from 'fp-ts/lib/Either';
import { fromEither, left, right } from 'fp-ts/lib/TaskEither';

const LESSONS = [
  {
    id: 1,
    title: 'Lektion 1',
    thumbnail: '1',
    moduleId: 1,
  },
];

function findById(id: LessonId): TaskResult<Lesson> {
  const found = LESSONS.find((lesson) => lesson.id === id);
  if (found) {
    return fromEither(Lesson(found));
  } else {
    return left([new Error('Lesson could not be found')]);
  }
}

function find(): TaskResult<Lesson[]> {
  return right(Lessons(LESSONS));
}

function create(row: UnsavedLesson): TaskResult<Lesson> {
  const newId = getNewId();
  const newLesson = Lesson({
    id: newId,
    title: row.title,
    thumbnail: row.thumbnail,
    moduleId: row.moduleId,
  });

  if (isRight(newLesson)) {
    LESSONS.push(newLesson.right);
  }

  return fromEither(newLesson);
}

function update(row: Lesson): TaskResult<Lesson> {
  const index = LESSONS.findIndex((lesson) => lesson.id === row.id);
  if (index < 0) {
    return left([new Error('Lesson could not be found')]);
  } else {
    LESSONS.splice(index, 1, row);
    return right(row);
  }
}

function remove(id: LessonId): TaskResult<null> {
  const index = LESSONS.findIndex((lesson) => lesson.id === id);
  if (index < 0) {
    return left([new Error('Lesson could not be found')]);
  } else {
    LESSONS.splice(index, 1);
    return right(null);
  }
}

function getNewId() {
  return LESSONS.reduce((acc, cur) => (cur.id > acc ? cur.id : acc), 0) + 1;
}

export const LessonRepository = {
  findById,
  find,
  create,
  update,
  remove,
};
