import { TaskResult } from '@domain';
import { isRight } from 'fp-ts/lib/Either';
import { Response } from 'express';

export function respond(res: Response) {
  return async (taskEither: TaskResult<any>): Promise<void> => {
    const requestResult = await taskEither();
    if (isRight(requestResult)) {
      res.send(requestResult.right);
    } else {
      const messages = requestResult.left.map((error) => error.message);
      res.send(messages);
    }
  };
}
