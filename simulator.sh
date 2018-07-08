timestamp() {
  date +"%T"
}


while true; do
	sleep $(( ( RANDOM % 10 )  + 1 ))
	curl http://localhost/hello-world?message=$(timestamp);
done
