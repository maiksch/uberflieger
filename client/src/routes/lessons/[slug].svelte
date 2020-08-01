<script context="module">
	export async function preload({ params, query }) {
		const res = await this.fetch(`http://localhost:3000/lessons/1`);
		const lesson = await res.json();
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
	<title>Uberflieger - {lesson.title}</title>
</svelte:head>

<h1>{lesson.title}</h1>

<video crossorigin="anonymous" preload="auto" controls>
	<source src="small.webm" type="video/webm" />
</video>
