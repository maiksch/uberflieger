import { writable } from 'svelte/store';

export interface Breadcrumb {
	link?: string;
	label: string;
}
export const breadcrumbs$ = writable<Breadcrumb[]>([]);
