import { Maybe } from "@/core/utils/maybe";
import { Category } from "../models/category/model";

export interface ICategoriesRepository {
    getCategories: () => Promise<Maybe<Category[]>>;
}