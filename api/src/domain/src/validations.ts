import { left, right } from 'fp-ts/lib/Either';
import {
  EMPTY_VALIDATION_ERROR,
  NOT_A_NUMBER_VALIDATION_ERROR,
  MAX_LENGTH_VALIDATION_ERROR,
  NOT_POSITIVE_VALIDATION_ERROR,
  ValidationResult,
} from './results';

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
