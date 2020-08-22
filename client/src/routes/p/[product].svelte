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
		background-color: white;
		padding: 1em;
	}

	section + section {
		margin-top: 2em;
	}

	.container {
		display: flex;
	}

	#left {
		width: 66.66666%;
	}

	#thumbnail {
		width: 33.333333%;
		margin-left: 2em;
	}

	img {
		width: 100%;
	}

	ul {
		list-style: none;
		padding: 0;
	}

	.progress_title {
		font-weight: bold;
	}

	.progress-bar {
		width: 100%;
		height: 1em;
	}

	.progress-bar > .fill {
		background-color: #0ab3ea;
		height: 100%;
	}

	.progress-bar_percent {
		color: white;
		position: fixed;
	}

	button {
		width: 100%;
		padding: 1em;
	}
</style>

<svelte:head>
	<title>{product.title}</title>
</svelte:head>

<h1>{product.title}</h1>

<div class="container">
	<div id="left">
		<section id="description">{product.description}</section>

		<section id="progress">
			<span class="progress_title">Fortschritt</span>
			<div class="progress-bar">
				<span class="progress-bar_percent">{progress * 100}%</span>
				<div class="fill" style="width: {progress * 100}%" />
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

	<div id="thumbnail">
		<img src={product.thumbnail} alt={product.title} />
		<button>Weiter schauen</button>
	</div>
</div>
