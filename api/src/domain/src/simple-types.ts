import { chain, map, mapLeft } from 'fp-ts/lib/Either';
import { pipe } from 'fp-ts/lib/function';
import { Result, Errors, ValidationError, ValidationResult } from './results';
import { isNotEmpty, isNumber, isPositive, maxLength } from './validations';

/**
 * Module
 */
export type ProductId = number & { _type_: 'ProductId' };
export function ProductId(id: number): ProductId {
	return id as ProductId;
}
export function createProductId(id: number): Result<ProductId> {
	return pipe(
		isNotEmpty(id),
		chain(isNumber),
		chain(isPositive),
		addErrorContext('Product Id'),
		map(ProductId)
	);
}
/**
 * Module
 */
export type ModuleId = number & { _type_: 'ModuleId' };
export function ModuleId(id: number): ModuleId {
	return id as ModuleId;
}
export function createModuleId(id: number): Result<ModuleId> {
	return pipe(
		isNotEmpty(id),
		chain(isNumber),
		chain(isPositive),
		addErrorContext('Module Id'),
		map(ModuleId)
	);
}

/**
 * Lesson
 */
export type LessonId = number & { _type_: 'LessonId' };
export function LessonId(id: number): LessonId {
	return id as LessonId;
}
export function createLessonId(id: number): Result<LessonId> {
	return pipe(
		isNotEmpty(id),
		chain(isNumber),
		chain(isPositive),
		addErrorContext('Lesson Id'),
		map(LessonId)
	);
}

export type LessonThumbnail = string & { _type_: 'LessonThumbnail' };
export function LessonThumbnail(thumbnailUrl: string): LessonThumbnail {
	return thumbnailUrl as LessonThumbnail;
}
export function createLessonThumbnail(value: string): Result<LessonThumbnail> {
	return pipe(
		isNotEmpty(value),
		chain(maxLength(256)),
		addErrorContext('Thumbnail'),
		map(LessonThumbnail)
	);
}

/**
 * Video
 */
export type VideoId = number & { _type_: 'VideoId' };
export type VideoUrl = string & { _type_: 'VideoUrl' };

/**
 * String256
 */

export type String256 = string & { _type_: 'String256' };
export function String256(value: string): String256 {
	return value as String256;
}
export function createString256(
	value: string
): (context: string) => Result<String256> {
	return (context: string) => {
		return pipe(
			isNotEmpty(value),
			chain(maxLength(256)),
			addErrorContext(context),
			map(String256)
		);
	};
}

/**
 * Text
 */

export type Text = string & { _type_: 'Text' };
export function Text(value: string): Text {
	return value as Text;
}
export function createText(value: string): (context: string) => Result<Text> {
	return (context: string) => {
		return pipe(
			isNotEmpty(value),
			chain(maxLength(65535)),
			addErrorContext(context),
			map(Text)
		);
	};
}

function addErrorContext(
	context: string
): <A>(a: ValidationResult<A>) => Result<A> {
	return mapLeft((error: ValidationError) => [
		new Error(`${context} ${error}`),
	]);
}
