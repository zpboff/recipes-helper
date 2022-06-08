import '../styles/globals.css'
import type { AppProps } from 'next/app'
import { Layout, LayoutProps } from '../components/Layout'

function MyApp({ Component, pageProps }: AppProps<LayoutProps>) {
  return (
      <Layout title={pageProps.title} description={pageProps.description}>
        <Component {...pageProps} />
      </Layout>
  )
}

export default MyApp
