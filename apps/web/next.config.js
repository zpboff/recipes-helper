/** @type {import('next').NextConfig} */
const nextConfig = {
  output: "standalone",
  images: {
    remotePatterns: [
      {
        protocol: 'https',
        hostname: 'img.spoonacular.com',
        port: '',
        pathname: '/recipes/**',
      },
    ],
  },
}

module.exports = nextConfig
