import { ProductService } from 'application/products/src/product-service';
import { RequestHandler } from 'express';
import { pipe } from 'fp-ts/lib/function';
import { respond } from '../common/respond';

const create: RequestHandler = async (req, res) => {
	// await pipe(LessonService.create(req.body), respond(res));
};

const getList: RequestHandler = async (req, res) => {
	await pipe(ProductService.getList(), respond(res));
};

const getOne: RequestHandler = async (req, res) => {
	// await pipe(ProductService.getOne(+req.params.id), respond(res));
	res.send({
		id: 1,
		title: 'Outcome-based Leadership',
		identifier: 'outcome-based-leadership',
		description: `Im Outcome-based Leadership Programm lernst du, wie du nachhaltig Führungskompetenzen aufbaust und dich Schritt-für-Schritt zu einer erfolgreichen Führungskraft entwickelst. Dies ist ein "Umsetzungsprogramm", das dir dabei hilft, erstklassige Ergebnisse zu erzielen.`,
		modules: [
			{
				id: 1,
				identifier: 'modul-1-persönliches-wachstum',
				title: 'Modul 1 - Persönliches Wachstum',
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

const ProductController = {
	getList,
	getOne,
};

export default ProductController;
