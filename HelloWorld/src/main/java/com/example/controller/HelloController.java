package com.example.controller;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import java.net.InetAddress;
import java.net.UnknownHostException;

@RestController
public class HelloController {

    @RequestMapping(value = "/hello", method = RequestMethod.GET)
    public String index() throws UnknownHostException {
        return "Server name:" + InetAddress.getLocalHost().getHostName() + ", IP:" + InetAddress.getLocalHost().getHostAddress();
    }
}