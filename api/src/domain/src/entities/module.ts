import { ModuleId, String256, ProductId } from '../simple-types';

export interface Module {
	id: ModuleId;
	productId: ProductId;
	title: String256;
}
