import type { Module } from './module';

export interface Product {
	identifier: string;
	title: string;
	modules: Module[];
	description: string;
	thumbnail: string;
}
