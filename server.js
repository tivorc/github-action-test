const http = require('http');

const server = http.createServer((_, res) => {
  res.end('Hello World');
});

server.listen(6000, () => {
  console.log('Server is running...', server.address());
});
