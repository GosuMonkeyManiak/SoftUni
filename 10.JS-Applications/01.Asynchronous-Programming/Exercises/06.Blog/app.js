function attachEvents() {
    let postSelectRef = document.getElementById('posts');
    let commentsList = document.getElementById('post-comments');
    
    document.getElementById('btnLoadPosts').addEventListener('click', async e => {
        let url = `http://localhost:3030/jsonstore/blog/posts`;

        let response = await fetch(url);
        let data = await response.json();

        for (const postId of Object.keys(data)) {
            postSelectRef.appendChild(createOptionForPost(data[postId]));
        }
    });

    document.getElementById('btnViewPost').addEventListener('click', async e => {
        let postId = postSelectRef.options[postSelectRef.selectedIndex].value;

        let url = `http://localhost:3030/jsonstore/blog/comments`;

        let post = await getPostById(postId);

        document.getElementById('post-title').textContent = post.title;
        document.getElementById('post-body').textContent = post.body;

        let response = await fetch(url);
        let allComments = await response.json();

        let commnetsForCurrentPost = [];

        for (const commentId of Object.keys(allComments)) {

            if (allComments[commentId].postId == postId) {
                commnetsForCurrentPost.push(allComments[commentId]);
            }
        }
        
        commentsList.innerHTML = '';

        commnetsForCurrentPost.forEach(comment => {
            commentsList.appendChild(createLiForPostCommnet(comment));
        });
    });
    
    function createOptionForPost(post) {
        let option = document.createElement('option');
        option.value = post.id;
        option.textContent = post.title;

        return option;
    }

    function createLiForPostCommnet(comment) {
        let commentLi = document.createElement('li');
        commentLi.textContent = comment.text;
        commentLi.id = comment.id;

        return commentLi;
    }

    async function getPostById(postId) {
        let url = `http://localhost:3030/jsonstore/blog/posts/${postId}`;

        let response = await fetch(url);
        let post = await response.json();

        return post;
    }
}

attachEvents();