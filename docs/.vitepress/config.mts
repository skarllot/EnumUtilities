import {defineConfig} from 'vitepress'

// https://vitepress.dev/reference/site-config
export default defineConfig({
  title: "Raiqub Enum Utilities",
  lang: "en-US",
  description: "A source generator for C# that uses Roslyn to create extensions, parsers and JSON converters for enumerations",
  lastUpdated: true,

  head: [
    ['link', { rel: "apple-touch-icon", sizes: "180x180", href: "/EnumUtilities/apple-touch-icon.png" }],
    ['link', { rel: "icon", type: "image/png", sizes: "32x32", href: "/EnumUtilities/favicon-32x32.png" }],
    ['link', { rel: "icon", type: "image/png", sizes: "16x16", href: "/EnumUtilities/favicon-16x16.png" }],
    ['link', { rel: "manifest", href: "/EnumUtilities/manifest.json" }],
    ['meta', { property: 'og:title', content: 'Raiqub Enum Utilities' }],
    ['meta', { property: 'og:type', content: 'website' }],
    ['meta', {
      property: 'og:description',
      content: 'A source generator for C# that uses Roslyn to create extensions, parsers and JSON converters for enumerations'
    }],
    ['meta', { property: 'og:url', content: 'https://fgodoy.me/EnumUtilities/' }]
  ],

  themeConfig: {
    // https://vitepress.dev/reference/default-theme-config
    nav: [
      { text: 'Home', link: '/' },
      { text: 'Examples', link: '/examples' }
    ],

    logo: '/favicon-128x128.png',

    search: {
      provider: "local"
    },

    sidebar: [
      {
        text: 'Introduction',
        items: [
          { text: 'Getting Started', link: '/introduction/' },
          { text: 'Basic Usage', link: '/introduction/basic-usage' },
          { text: 'Flags Enums', link: '/introduction/bit-flags' },
          { text: 'Metadata', link: '/introduction/metadata' }
        ]
      },
      {
        text: 'Members Attributes',
        items: [
          { text: 'Overview', link: '/members-attributes/' },
          { text: 'EnumMember', link: '/members-attributes/enum-member-attribute' },
          { text: 'Description', link: '/members-attributes/description-attribute' },
          { text: 'Dispaly', link: '/members-attributes/display-attribute' }
        ]
      },
      {
        text: 'JSON Serialization',
        items: [
          { text: 'Overview', link: '/json/' }
        ]
      }
    ],

    socialLinks: [
      { icon: 'github', link: 'https://github.com/skarllot/EnumUtilities' }
    ],

    footer: {
      message: 'Released under the MIT License.',
      copyright: 'Copyright © Fabricio Godoy and contributors.'
    },
    editLink: {
      pattern: 'https://github.com/skarllot/EnumUtilities/edit/main/docs/:path',
      text: 'Edit this page on GitHub'
    }
  },

  base: '/EnumUtilities/',
  sitemap: {
    hostname: 'https://fgodoy.me/EnumUtilities/'
  }
})
