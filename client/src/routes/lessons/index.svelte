<script context="module">
	export async function preload({ params, query }) {
		const res = await this.fetch(`http://localhost:3000/lessons`);
		const lessons = await res.json();
		return { lessons };
	}
</script>

<script>
	export let lessons;
</script>

<svelte:head>
	<title>Uberflieger Lessons</title>
</svelte:head>

<h1>Lessons</h1>

<ul>
	{#each lessons as lesson}
		<li>
			<a rel="prefetch" href="lessons/{lesson.id}">{lesson.title}</a>
		</li>
	{/each}
</ul>
