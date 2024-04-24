# dokumentace
https://github.com/stoplightio/prism

# instalace prism (macos + homebrew)
brew install --cask prism

# instalace prism (npm / yarn)
npm install -g @stoplight/prism-cli
yarn global add @stoplight/prism-cli

# prism mock
prism mock ./path-to-oas.yaml

# prism proxy
prism proxy ./path-to-oas.yaml https://api.production.cz

# nastavení HTTP hlaviček
Prefer  example=Example X
Prefer  code=200
Prefer  code=200,example=Example X
Prefer  code=400