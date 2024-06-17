import { Maybe } from "@/core/utils/maybe";
import { ISearchRecipeRepository } from "@/domain/repositories/ISearchRecipeRepository";
import { Recipe } from "./model";

export interface ISearchRecipeService {
    search: (searchRecipeRepository: ISearchRecipeRepository, query: string) => Promise<Maybe<Recipe[]>>;
}