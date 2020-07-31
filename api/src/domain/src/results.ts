import { Either } from 'fp-ts/lib/Either';
import { TaskEither } from 'fp-ts/lib/TaskEither';

export type Result<TSuccess> = Either<Errors, TSuccess>;
export type TaskResult<TSuccess> = TaskEither<Errors, TSuccess>;
export type Errors = Array<AppError>;
export type AppError = Error;

export const EMPTY_VALIDATION_ERROR = 'can not be empty';
export const NOT_A_NUMBER_VALIDATION_ERROR = 'is not a number';
export const MAX_LENGTH_VALIDATION_ERROR = 'is too long';
export const NOT_POSITIVE_VALIDATION_ERROR = 'must be positive';
export type ValidationResult<TSuccess> = Either<ValidationError, TSuccess>;
export type ValidationError =
  | typeof EMPTY_VALIDATION_ERROR
  | typeof NOT_A_NUMBER_VALIDATION_ERROR
  | typeof MAX_LENGTH_VALIDATION_ERROR
  | typeof NOT_POSITIVE_VALIDATION_ERROR;
