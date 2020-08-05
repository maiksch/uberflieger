import { createProductId, Product, Result, TaskResult } from '@domain';
import { pipe } from 'fp-ts/lib/function';
import { chain, fromEither } from 'fp-ts/lib/TaskEither';
import { ProductRepository } from 'infrastructure/src/product-repository';

// function create(dto: CreateLessonDto): TaskResult<Lesson> {
//   return pipe(UnsavedLesson(dto), chainFromEither(LessonRepository.create));
// }

function getList(): TaskResult<Product[]> {
	return ProductRepository.find();
}

function getOne(id: number): TaskResult<Product> {
	return pipe(createProductId(id), chainFromEither(ProductRepository.findById));
}

// function update(dto: UpdateLessonDto): TaskResult<Lesson> {
//   return pipe(Lesson(dto), chainFromEither(LessonRepository.update));
// }

// function remove(id: number): TaskResult<null> {
//   return pipe(createLessonId(id), chainFromEither(LessonRepository.remove));
// }

export const ProductService = {
	getList,
	getOne,
};

function chainFromEither<A, B>(
	f: (a: A) => TaskResult<B>
): (ma: Result<A>) => TaskResult<B> {
	return (ma: Result<A>) => {
		return pipe(fromEither(ma), chain(f));
	};
}
