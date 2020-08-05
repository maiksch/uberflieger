import {
	ProductId,
	String256,
	createString256,
	createProductId,
	Text,
	createText,
} from '../simple-types';
import { Result } from '../results';
import { validate } from '../validations';

export interface Product {
	id: ProductId;
	identifier: String256;
	title: String256;
	description: Text;
}

export function Product(input: {
	id: number;
	identifier: string;
	title: string;
	description: string;
}): Result<Product> {
	return validate({
		id: createProductId(input.id),
		identifier: createString256(input.identifier),
		title: createString256(input.title),
		description: createText(input.description),
	});
}
