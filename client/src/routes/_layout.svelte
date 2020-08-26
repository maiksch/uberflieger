<script>
	import Navbar from '../components/Nav/Navbar.svelte';

	export let segment: string;
</script>

<style global>
	main {
		position: relative;
		max-width: 1200px;
		padding: 2em;
		margin: 0 auto;
		box-sizing: border-box;
	}
</style>

<header>
	<Navbar />
</header>

<main>
	<slot />
</main>
