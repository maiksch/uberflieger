<script>
	import { breadcrumbs$ } from 'store';
	import type { Breadcrumb } from 'store';

	let breadcrumbs: Breadcrumb[];

	breadcrumbs$.subscribe((value) => (breadcrumbs = value));
</script>

<style>
	a {
		text-decoration: none;
		display: block;
		color: black;
	}

	.breadcrumb,
	.seperator {
		padding: 1em 0.5em;
	}

	.seperator {
		color: grey;
	}

	.breadcrumbs {
		padding-left: 1em;
		display: flex;
	}
</style>

<div class="breadcrumbs">
	{#each breadcrumbs as breadcrumb, idx}
		{#if idx > 0}
			<div class="seperator">→</div>
		{/if}
		<div class="breadcrumb">
			<a href={breadcrumb.link}>{breadcrumb.label}</a>
		</div>
	{/each}
</div>
