<script>
	import { onMount } from 'svelte';
	import * as api from 'api';
	import type { Product } from 'models';
	import { breadcrumbs$ } from 'store';

	let products: Product[] = [];

	breadcrumbs$.set([]);

	onMount(async () => {
		products = await api.get('products');
	});
</script>

<svelte:head>
	<title>Uberflieger</title>
</svelte:head>

<h1>Produkte</h1>

<ul>
	{#each products as product}
		<li>
			<a rel="prefetch" href="p/{product.identifier}">{product.title}</a>
		</li>
	{/each}
</ul>
