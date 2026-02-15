#!/bin/sh
printf '\033c\033]0;%s\a' balls
base_path="$(dirname "$(realpath "$0")")"
"$base_path/Runner.x86_64" "$@"
