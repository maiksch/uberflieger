import { ProductService } from 'application/products/src/product-service';
import { RequestHandler } from 'express';
import { pipe } from 'fp-ts/lib/function';
import { respond } from '../common/respond';

const create: RequestHandler = async (req, res) => {
	// await pipe(LessonService.create(req.body), respond(res));
};

const getList: RequestHandler = async (req, res) => {
	res.send([
		{
			id: 1,
			productId: 1,
			title: 'Modul 1 - Persönliches Wachstum',
			lessons: [
				{
					id: 1,
					moduleId: 1,
					title: '1.1 Eigene Persönlichkeit',
					thumbnail: '1',
				},
			],
		},
	]);
};

const getOne: RequestHandler = async (req, res) => {
	res.send({
		id: 1,
		productId: 1,
		title: 'Modul 1 - Persönliches Wachstum',
		lessons: [
			{
				id: 1,
				moduleId: 1,
				title: '1.1 Eigene Persönlichkeit',
				thumbnail: '1',
			},
		],
	});
};

const update: RequestHandler = async (req, res) => {
	// await pipe(LessonService.update(req.body), respond(res));
};

const remove: RequestHandler = async (req, res) => {
	// await pipe(LessonService.remove(+req.params.id), respond(res));
};

const ModuleController = {
	getList,
	getOne,
};

export default ModuleController;
