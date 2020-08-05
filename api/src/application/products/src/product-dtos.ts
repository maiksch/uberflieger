// export interface CreateProductDto {
//   moduleId: number;
//   videoId?: number;
//   title: string;
//   thumbnail: string;
// }

// export interface UpdateProductDto {
//   id: number;
//   moduleId: number;
//   videoId?: number;
//   title: string;
//   thumbnail: string;
// }

export interface ProductDto {
	id: number;
	title: string;
	description: string;
	modules: any[];
}
