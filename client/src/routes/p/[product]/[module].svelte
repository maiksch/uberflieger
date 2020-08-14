<script context="module">
	import * as api from 'api';

	export async function preload({ path, params, query }) {
		const module = await api.get(`modules/${params.module}`);
		return { module, path };
	}
</script>

<script>
	export let module;
	export let path;
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
	<title>{module.title}</title>
</svelte:head>

<h1>{module.title}</h1>

<ul>
	{#each module.lessons as lesson}
		<li>
			<a rel="prefetch" href="{path}/lessons/{lesson.id}">{lesson.title}</a>
		</li>
	{/each}
</ul>
