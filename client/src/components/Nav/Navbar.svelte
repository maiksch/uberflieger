<script>
	import Breadcrumbs from './Breadcrumbs.svelte';
</script>

<style>
	nav {
		border-bottom: 1px solid #e5e7eb;
		background-color: white;
		display: flex;
	}

	a {
		text-decoration: none;
		display: block;
		color: black;
	}

	.logo {
		padding: 1em 2em;
		border-right: 1px solid #e5e7eb;
		font-weight: bold;
	}
</style>

<nav>
	<a class="logo" href="/">Uberflieger</a>
	<Breadcrumbs />
</nav>
