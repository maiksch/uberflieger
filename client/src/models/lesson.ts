import type { Module } from './module';
import type { Product } from './product';

export interface Lesson {
	lessonNo: number;
	title: string;
	videoContentType: string;
	module: Module;
	product: Product;
}
