const config = {
    streamProxyUrl: process.env.VUE_APP_STREAM_PROXY_URL,
    streamUrl: process.env.VUE_APP_STREAM_URL,
    feedUrl: process.env.VUE_APP_FEED_URL,
    circularSettings: {
        minRotate: 0,
        maxRotate: 360,
        speed: 8400
    }
}

export {
    config
}