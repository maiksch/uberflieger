<script context="module">
	import * as api from 'api';

	export async function preload({ params, query }) {
		const lesson = await api.get(`lessons/${params.lesson}`);
		return { lesson };
	}
</script>

<script>
	export let lesson;
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
	<title>{lesson.title}</title>
</svelte:head>

<h1>{lesson.title}</h1>

<video crossorigin="anonymous" preload="auto" controls>
	<source src="small.webm" type="video/webm" />
</video>
