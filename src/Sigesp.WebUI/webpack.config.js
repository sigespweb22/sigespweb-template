const path = require('path');
const Dotenv = require('dotenv-webpack');

module.exports = {
  entry: './wwwroot/index.ts',
  plugins: [
    new Dotenv()
  ],
  module: {
    rules: [
      {
        test: /\.tsx?$/,
        use: 'ts-loader',
        exclude: /node_modules/,
      },
    ],
  },
  resolve: {
    extensions: ['.tsx', '.ts', '.js'],
  },
  output: {
    library: {
      name: 'bobcatJS',
      type: 'var'
    },
    filename: 'app-client.js',
    path: path.resolve(__dirname, 'wwwroot/js/scripts'),
  }
};