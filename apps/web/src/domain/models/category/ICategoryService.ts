import { Maybe } from "@/core/utils/maybe";
import { Category } from "./model";
import { ICategoryRepository } from "@/domain/repositories/ICategoryRepository";

export interface ICategoryService {
    getCategories: (categoryRepository: ICategoryRepository) => Promise<Maybe<Category[]>>;
}