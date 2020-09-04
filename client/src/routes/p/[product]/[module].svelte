<script context="module">
	import * as api from 'api';

	export async function preload({ path, params }: any) {
		const module = await api.get(`modules/${params.module}`);
		return { module, path };
	}
</script>

<script>
	import type { Module } from 'models';
	import { breadcrumbs$ } from 'store';

	export let module: Module;
	export let path: string;

	breadcrumbs$.set([
		{
			label: module.product.title,
			link: `/p/${module.product.identifier}`,
		},
		{
			label: module.title,
			link: path,
		},
	]);
</script>

<style>
	h1 {
		font-size: 2em;
		text-transform: uppercase;
		font-weight: 700;
		margin: 0 0 0.5em 0;
	}

	#left {
		width: 66.66666%;
	}

	#thumbnail {
		width: 33.333333%;
	}

	section {
		padding: 1.25rem;
		background-color: #fff;
	}

	section + section {
		margin-top: 1.25rem;
	}

	ul {
		list-style: none;
		padding: 0;
	}

	.flex {
		display: flex;
	}

	.flex-col {
		flex-direction: column;
	}

	.ml-12 {
		margin-left: 3rem;
	}

	.w-full {
		width: 100%;
	}
</style>

<svelte:head>
	<title>{module.title}</title>
</svelte:head>

<h1>{module.title}</h1>

<div class="flex">
	<div id="left">
		<section id="lessons">
			<h2>Lektionen</h2>
			<ul>
				{#each module.lessons as lesson}
					<li>
						<a rel="prefetch" href="{path}/lessons/{lesson.lessonNo}">
							{lesson.title}
						</a>
					</li>
				{/each}
			</ul>
		</section>
	</div>

	<div id="thumbnail" class="flex flex-col ml-12">
		<img class="w-full" src={module.product.thumbnail} alt={module.title} />
		<!-- <Button>Weiter schauen</Button> -->
	</div>

</div>
