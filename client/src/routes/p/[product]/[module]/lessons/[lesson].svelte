<script context="module">
	import * as api from 'api';

	export async function preload({ params, path }: any) {
		const url = `modules/${params.module}/lesson/${params.lesson}`;
		const lesson = await api.get(url);
		return { lesson, path };
	}
</script>

<script>
	import type { Lesson } from 'models';
	import { breadcrumbs$ } from 'store';

	export let lesson: Lesson;
	export let path: string;

	const video = `http://localhost:5000/lessons/${lesson.lessonNo}/video`;

	breadcrumbs$.set([
		{
			label: lesson.product.title,
			link: `/p/${lesson.product.identifier}`,
		},
		{
			label: lesson.module.title,
			link: `/p/${lesson.product.identifier}/${lesson.module.identifier}`,
		},
		{
			label: lesson.title,
			link: path,
		},
	]);
</script>

<style>
	h1 {
		text-align: center;
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

<video
	crossorigin="anonymous"
	preload="auto"
	controls
	controlsList="nodownload">
	<source src={video} type={lesson.videoContentType} />
	<track kind="captions" />
</video>
