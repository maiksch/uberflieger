<style>
	button {
		margin-top: 1em;
		display: flex;
		justify-content: center;

		padding: 0.5rem 1rem;
		border-radius: 0.25rem;

		background-color: #4299e1;

		color: #fff;
		font-weight: 700;
		cursor: pointer;
		border: none;
	}

	button:hover {
		background-color: #3182ce;
	}
</style>

<button>
	<slot />
</button>
