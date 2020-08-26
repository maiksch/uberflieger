import type { Lesson } from './lesson';
import type { Product } from './product';

export interface Module {
	identifier: string;
	title: string;
	lessons: Lesson[];
	product: {
		identifier: string;
		title: string;
	};
}
