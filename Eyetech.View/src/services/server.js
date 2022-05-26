const Server = () => {
  const host = window.location.hostname
  if (process.env.NODE_ENV === 'development') {
    return 'localhost:5000'
  } else {
    return host + ':5000'
  }
}

const ServerAlpr = () => {
  const host = window.location.hostname
  if (process.env.NODE_ENV === 'development') {
    return 'http://192.168.1.102:3000'
  } else {
    return 'http://' + host + ':3000'
  }
}

const hostServer = () => {
  const host = window.location.hostname
  if (process.env.NODE_ENV === 'development') {
    return 'http://localhost:5000'
  } else {
    return 'http://' + host + ':5000'
  }
}

const stream = () => {
  const host = window.location.hostname
  if (process.env.NODE_ENV === 'development') {
    return 'ws://192.168.1.102:9999/camera1'
  } else {
    return 'ws://' + host + ':9999/camera1'
  }
}

export default { hostServer, stream, Server, ServerAlpr }
