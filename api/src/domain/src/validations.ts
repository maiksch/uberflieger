import { isLeft, left, right } from 'fp-ts/lib/Either';
import {
	EMPTY_VALIDATION_ERROR,
	MAX_LENGTH_VALIDATION_ERROR,
	NOT_A_NUMBER_VALIDATION_ERROR,
	NOT_POSITIVE_VALIDATION_ERROR,
	Result,
	ValidationResult,
} from './results';

// function validate() {
//   return sequenceS(getValidation(getSemigroup<Error>()));
// }

export function validate<A>(
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

export function isNotEmpty<T>(input: T): ValidationResult<T> {
	if (typeof input === 'string' && input != null && input.length === 0) {
		return left(EMPTY_VALIDATION_ERROR);
	}
	if (Array.isArray(input) && input.length === 0) {
		return left(EMPTY_VALIDATION_ERROR);
	}
	if (input == null) {
		return left(EMPTY_VALIDATION_ERROR);
	} else {
		return right(input);
	}
}

export function isPositive(input: number): ValidationResult<number> {
	if (input <= 0) {
		return left(NOT_POSITIVE_VALIDATION_ERROR);
	} else {
		return right(input);
	}
}

export function isNumber(input: any): ValidationResult<number> {
	if (!Number.isInteger(input)) {
		return left(NOT_A_NUMBER_VALIDATION_ERROR);
	} else {
		return right(input);
	}
}

export function maxLength(
	max: number
): (input: string | Array<any>) => ValidationResult<string | Array<any>> {
	return (input: string | Array<any>) => {
		if (input == null || input.length >= max) {
			return left(MAX_LENGTH_VALIDATION_ERROR);
		} else {
			return right(input);
		}
	};
}
