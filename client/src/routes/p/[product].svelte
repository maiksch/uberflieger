<script context="module">
	import * as api from 'api';

	export async function preload({ path, params }: any) {
		const product = await api.get(`products/${params.product}`);
		return { product, path };
	}
</script>

<script>
	import type { Product } from 'models';
	import { breadcrumbs$ } from 'store';
	import Button from '../../components/Button.svelte';

	export let product: Product;
	export let path: string;

	breadcrumbs$.set([{ label: product.title, link: path }]);

	const progress = 0.8;
</script>

<style>
	h1 {
		font-size: 2em;
		text-transform: uppercase;
		font-weight: 700;
		margin: 0 0 0.5em 0;
	}

	section {
		padding: 1.25rem;
		background-color: #fff;
	}

	section + section {
		margin-top: 1.25rem;
	}

	#left {
		width: 66.66666%;
	}

	#thumbnail {
		width: 33.333333%;
	}

	ul {
		list-style: none;
		padding: 0;
	}

	.flex {
		display: flex;
	}

	.font-bold {
		font-weight: bold;
	}

	.w-full {
		width: 100%;
	}

	.text-white {
		color: #fff;
	}

	.fixed {
		position: fixed;
	}

	.bg-blue-500 {
		background-color: #4299e1;
	}

	.rounded {
		border-radius: 0.25rem;
	}

	.h-full {
		height: 100%;
	}

	.flex-col {
		flex-direction: column;
	}

	.ml-12 {
		margin-left: 3rem;
	}
</style>

<svelte:head>
	<title>{product.title}</title>
</svelte:head>

<h1>{product.title}</h1>

<div class="flex">
	<div id="left">
		<section id="description">{product.description}</section>

		<section id="progress">
			<span class="font-bold">Fortschritt</span>
			<div class="w-full h-5">
				<span class="fixed text-white">{progress * 100}%</span>
				<div
					class="bg-blue-500 h-full rounded"
					style="width: {progress * 100}%" />
			</div>
		</section>

		<section id="modules">
			<h2>Module</h2>
			<ul>
				{#each product.modules as module}
					<li>
						<a rel="prefetch" href="{path}/{module.identifier}">
							{module.title}
						</a>
					</li>
				{/each}
			</ul>
		</section>
	</div>

	<div id="thumbnail" class="flex flex-col ml-12">
		<img class="w-full" src={product.thumbnail} alt={product.title} />
		<Button>Weiter schauen</Button>
	</div>
</div>
