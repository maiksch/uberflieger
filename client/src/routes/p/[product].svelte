<script context="module">
	import * as api from 'api';

	export async function preload({ path, params }: any) {
		const product = await api.get(`products/${params.product}`);
		return { product, path };
	}
</script>

<script>
	import type { Product } from 'models';

	export let product: Product;
	export let path: string;
</script>

<style>
	h1 {
		text-align: center;
		margin: 0 auto;
	}

	h1 {
		font-size: 2.8em;
		text-transform: uppercase;
		font-weight: 700;
		margin: 0 0 0.5em 0;
	}

	@media (min-width: 480px) {
		h1 {
			font-size: 4em;
		}
	}
</style>

<svelte:head>
	<title>{product.title}</title>
</svelte:head>

<h1>{product.title}</h1>

<ul>
	{#each product.modules as module}
		<li>
			<a rel="prefetch" href="{path}/{module.identifier}">{module.title}</a>
		</li>
	{/each}
</ul>
