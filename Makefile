all: docker

git.tar.gz:
	tar czf git.tar.gz .git

docker: git.tar.gz Dockerfile
	if [ ! -e ".image_built" ]; then \
	    docker build -t kongo2002/centos-servicestack . && touch .image_built; \
	fi

run: docker
	docker run -P kongo2002/centos-servicestack

interactive: docker
	docker run -i -t -P --rm kongo2002/centos-servicestack

clean:
	@rm -f .image_built
	@rm -f git.tar.gz
