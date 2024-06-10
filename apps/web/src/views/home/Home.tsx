import { PageLayout } from "@/layouts/page-layout/ui";
import { Heading, Flex } from "@radix-ui/themes";
import styles from './home.module.scss';
import { RecipeList } from "../../widgets/recipe-list";

export default function Home() {
  return (
      <PageLayout>
          <Flex className={styles.page} justify="center" direction="column">
            <Heading size="7" className={styles.heading}>Новые рецепты</Heading>
            <RecipeList />
          </Flex>
      </PageLayout>
  )
}
