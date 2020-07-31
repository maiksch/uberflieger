import { Router } from 'express';
import LessonController from './controllers/lesson-controller';

const router = () => {
  return Router().use(
    Router()
      .post('/lessons', LessonController.create)
      .get('/lessons', LessonController.getList)
      .get('/lessons/:id', LessonController.getOne)
      .patch('/lessons/:id', LessonController.update)
      .delete('/lessons/:id', LessonController.remove)
      .get('/lessons/:id/video', LessonController.streamVideo)
  );
};

export default router;
