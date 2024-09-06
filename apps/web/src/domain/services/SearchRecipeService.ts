import { ISearchRecipeService } from "../models/recipe/ISearchRecipeService";
import { ISearchRecipeRepository } from "../repositories/ISearchRecipeRepository";

const search = (searchRecipeRepository: ISearchRecipeRepository, query: string) => {
    return searchRecipeRepository.search(query);
}

export const searchRecipeService: ISearchRecipeService = { search }