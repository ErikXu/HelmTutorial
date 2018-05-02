package com.example.controller;

import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.multipart.MultipartFile;

@RestController
@RequestMapping(value = "api/releases")
public class ReleaseController {
    @RequestMapping(value = "{name}", method = RequestMethod.POST)
    public ResponseEntity<Object> install(@PathVariable("name") String name, @RequestParam("file") MultipartFile file) {
        return ResponseEntity.ok("Hello " + name);
    }

    @RequestMapping(value = "{name}/{purge}", method = RequestMethod.DELETE)
    public ResponseEntity<Object> uninstall(@PathVariable("name") String name, @PathVariable("purge") Boolean purge) {
        return ResponseEntity.ok("");
    }

    @RequestMapping(value = "{name}", method = RequestMethod.PUT)
    public ResponseEntity<Object> update(@PathVariable("name") String name, @RequestParam("file") MultipartFile file) {
        return ResponseEntity.ok("");
    }

    @RequestMapping(value = "{name}/{version}", method = RequestMethod.PUT)
    public ResponseEntity<Object> rollback(@PathVariable("name") String name, @PathVariable("version") int version) {
        return ResponseEntity.ok("");
    }
}
