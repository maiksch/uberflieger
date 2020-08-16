interface RequestOptions {
	method: string;
	headers: { [name: string]: string };
	body?: any;
}

const base =
	process.env.NODE_ENV === 'development' ? 'http://localhost:5000' : '';

async function send({
	method,
	path,
	data: body,
	token,
}: {
	method: string;
	path: string;
	data?: any;
	token?: string;
}) {
	const fetch = (process as any).browser
		? window.fetch
		: require('node-fetch').default;

	const opts: RequestOptions = { method, headers: {} };

	if (body) {
		opts.headers['Content-Type'] = 'application/json';
		opts.body = JSON.stringify(body);
	}

	if (token) {
		opts.headers['Authorization'] = `Bearer ${token}`;
	}

	return fetch(`${base}/${path}`, opts)
		.then((r: any) => r.text())
		.then((json: any) => {
			try {
				return JSON.parse(json);
			} catch (err) {
				return json;
			}
		});
}

export function get(path: string, token?: string) {
	return send({ method: 'GET', path, token });
}

export function del(path: string, token?: string) {
	return send({ method: 'DELETE', path, token });
}

export function post(path: string, data: any, token?: string) {
	return send({ method: 'POST', path, data, token });
}

export function patch(path: string, data: any, token?: string) {
	return send({ method: 'PUT', path, data, token });
}
