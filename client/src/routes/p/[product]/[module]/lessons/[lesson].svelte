<script context="module">
	import * as api from 'api';

	export async function preload({ params }: any) {
		const url = `modules/${params.module}/lesson/${params.lesson}`;
		const lesson = await api.get(url);
		return { lesson };
	}
</script>

<script>
	import type { Lesson } from 'models';

	export let lesson: Lesson;
	const video = `http://localhost:5000/lessons/${lesson.lessonNo}/video`;
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

	video {
		width: 100%;
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
	<source src={video} type={lesson.videoContentType} />
	<track kind="captions" />
</video>
