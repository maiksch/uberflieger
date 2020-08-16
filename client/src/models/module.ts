import type { Lesson } from './lesson';

export interface Module {
	identifier: string;
	title: string;
	lessons: Lesson[];
}
