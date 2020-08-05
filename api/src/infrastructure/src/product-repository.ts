import { ProductId, Product, TaskResult } from '@domain';
import { fromEither, left, right } from 'fp-ts/lib/TaskEither';

const PRODUCTS = [
	{
		id: 1,
		identifier: 'outcome-based-leadership',
		title: 'Outcome-based Leadership',
		description: `Im Outcome-based Leadership Programm lernst du, wie du nachhaltig Führungskompetenzen aufbaust und dich Schritt-für-Schritt zu einer erfolgreichen Führungskraft entwickelst. Dies ist ein "Umsetzungsprogramm", das dir dabei hilft, erstklassige Ergebnisse zu erzielen.`,
	},
];

function findById(id: ProductId): TaskResult<Product> {
	const found = PRODUCTS.find((product) => product.id === id);
	if (found) {
		return fromEither(Product(found));
	} else {
		return left([new Error('Lesson could not be found')]);
	}
}

function find(): TaskResult<Product[]> {
	return right(PRODUCTS as Product[]);
}

export const ProductRepository = {
	findById,
	find,
};
