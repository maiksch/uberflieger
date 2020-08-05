import { Router } from 'express';
import LessonController from './controllers/lesson-controller';
import ModuleController from './controllers/module-controller';
import ProductController from './controllers/product-controller';

const router = () => {
	return Router()
		.use(
			Router()
				.post('/lessons', LessonController.create)
				.get('/lessons', LessonController.getList)
				.get('/lessons/:id', LessonController.getOne)
				.patch('/lessons/:id', LessonController.update)
				.delete('/lessons/:id', LessonController.remove)
				.get('/lessons/:id/video', LessonController.streamVideo)
		)
		.use(
			Router()
				.get('/products', ProductController.getList)
				.get('/products/:id', ProductController.getOne)
		)
		.use(
			Router()
				.get('/modules', ModuleController.getList)
				.get('/modules/:id', ModuleController.getOne)
		);
};

export default router;
