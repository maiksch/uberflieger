<script>
	import { onMount } from 'svelte';

	let products = [];

	onMount(async () => {
		const res = await fetch(`http://localhost:3000/products`);
		products = await res.json();
	});
</script>

<svelte:head>
	<title>Uberflieger</title>
</svelte:head>

<h1>Produkte</h1>

<ul>
	{#each products as product}
		<li>
			<a rel="prefetch" href="p/{product.identifier}">{product.title}</a>
		</li>
	{/each}
</ul>
